using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Face;
using System.IO;
using System.Threading.Tasks;

namespace FaceAPI_Services
{
    public class AzureHandler
    {
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
                return new Task<MemoryStream>();
            }
            var personList = await fsc.IdentifyAsync(APIKeys.getPersonGroupID(), faceIDs);
            var personIDs = personList.Select(x => x.Candidates[0].PersonId);

            ExtractPerson(personIDs);
        }

        private void ExtractPerson(IEnumerable<Guid> personIDs)
        {
            throw new NotImplementedException();
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