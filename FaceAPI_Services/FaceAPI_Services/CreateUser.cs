using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Face;
using System.IO;
using System.Threading.Tasks;
using FaceAPI_BusinessLayer;
using Microsoft.ProjectOxford.Face.Contract;

namespace FaceAPI_Services
{
    public class CreateUser
    {
        private PersonEntity personE;
        private FaceServiceClient fsc;
        private string personGroupID = "6368468496874";

        public AzureHandler()
        {
            fsc = new FaceServiceClient(APIKeys.GetSubscriptionKey(), APIKeys.GetAPIURL());
        }

        public async void CreateUserEntity(/*need pictures of User*/)
        {
            PersonEntity person = new PersonEntity(/*User Propertys*/);
            string FullName = person.FirstName + person.LastName;

            CreatePersonResult Person = await fsc.CreatePersonAsync(personGroupID, FullName);

            //Rewrite when stream with pictures is ready!
            foreach (string imagePath in Directory.GetFiles("<PATH_TO_PHOTOS_OF_PERSON_1>"))
            {
                using (Stream s = File.OpenRead(imagePath))
                {
                    await fsc.AddPersonFaceAsync(personGroupID, Person.PersonId, s);
                }
            }

            /*
             Programm the SQL connection -> Maybe a Query?
             */


        }
    }
}