using System;

public class Registration
{
	public Registration()
	{
        const string personGroupId = "6368468496874";
        const string friend1ImageDir = @"C:\Users\gtome\Downloads\gersa";
        foreach (string imagePath in Directory.GetFiles(friend1ImageDir, "*.jpg"))
        {
            using (Stream s = File.OpenRead(imagePath))
            {
                // Detect faces in the image and add to Gersa
                await faceServiceClient.AddPersonFaceAsync(
                    personGroupId, friend1.PersonId, s);
            }
        }
    }
}




