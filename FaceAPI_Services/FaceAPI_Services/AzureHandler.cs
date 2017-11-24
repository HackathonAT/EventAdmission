using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Face;
using System.IO;
using System.Threading.Tasks;
using FaceAPI_BusinessLayer;

namespace FaceAPI_Services
{
    public class AzureHandler
    {
        private PersonEntity personE;
        private FaceServiceClient fsc;

        public AzureHandler()
        {
            fsc = new FaceServiceClient(APIKeys.GetSubscriptionKey(), APIKeys.GetAPIURL());
        }

        public async Task<MemoryStream> DetectFaces(MemoryStream image)//image)
        {
            var attrs = new List<FaceAttributeType> { FaceAttributeType.Age};
            var faces = await fsc.DetectAsync(image, returnFaceAttributes: attrs);

            var faceIDs = faces.Select(x => x.FaceId).ToArray();
            if (faceIDs.Length == 0)
            {
                return await new Task<MemoryStream>(null);// Task<MemoryStream>();
            }
            var personList = await fsc.IdentifyAsync(APIKeys.getPersonGroupID(), faceIDs);
            var personIDs = personList.Select(x => x.Candidates[0].PersonId);

            var idPerson = ExtractPerson(personIDs);

            return Task<MemoryStream>(idPerson);
        }

        private PersonEntity ExtractPerson(IEnumerable<Guid> personIDs)
        {
            // Create a retrieve operation that takes a customer entity.
            foreach p in personIDs
                {
                TableOperation retrieveOperation = TableOperation.Retrieve<Person>(p);

                // Execute the retrieve operation.
                TableResult retrievedResult = await peopleTable.ExecuteAsync(retrieveOperation);

                // Print the phone number of the result.
                if (retrievedResult.Result != null)
                {
                    string FirstName = retrievedResult.Result.FirstName;
                    string LastName = retrievedResult.Result.LastName;
                    string Role = retrievedResult.Result.Role;
                    string Status = retrievedResult.Result.Status;
                    DateTime Birthday = retrievedResult.Result.Birthday;

                    personE = new PersonEntity(FirstName, LastName, Status, Role, Birthday);
                    return personE;
                }
                else
                    return new PersonEntity();
            }
        }

        
    }
}
/*
 * List<Person> persons = new List<Person>();
            //_timeStampQueue.Enqueue(DateTime.UtcNow);
            var jpg = frame.Image.ToMemoryStream(".jpg", s_jpegParams);
            var attrs = new List<FaceAttributeType> { FaceAttributeType.Age };
            //await WaitCallLimitPerSecondAsync();
            var faces = await _faceClient.DetectAsync(jpg, returnFaceAttributes: attrs);
            Properties.Settings.Default.FaceAPICallCount++;
            // Count the API call. 
            var faceIDs = faces.Select(x => x.FaceId).ToArray();
            Properties.Settings.Default.FaceAPICallCount++;
            if(faceIDs.Length==0)
            {
                return new LiveCameraResult();
            }
            var personList = await _faceClient.IdentifyAsync(personGroupID, faceIDs);
            Properties.Settings.Default.FaceAPICallCount++;
            string[] celebNames = new string[0];
            if (personList != null && personList[0] != null)
            {
                celebNames = new string[personList.Length];
                for (int i = 0; i < personList.Length; i++)
                {
                    if (personList[i].Candidates.Length > 0)
                    {
                        var result = personsInGroup.FindByID(personList[i].Candidates[0].PersonId);
                        celebNames[i] = result.Name;
                        persons.Add(result);
                    }
                    else
                    {
                        celebNames[i] = "Unknown person";
                        persons.Add(new Person());
                    }
                }
            }

            return new LiveCameraResult
            {
                Persons = persons.ToArray(),
                Faces = faces,
                CelebrityNames = celebNames 
            };
*/