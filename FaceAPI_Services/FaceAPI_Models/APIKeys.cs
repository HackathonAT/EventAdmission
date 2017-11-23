using System;

public class APIKeys
{
    private static string subscriptionKey = "9b79107888974f2cb26d8ce88720393a";
    private static string personGroupID = "6368468496874";
    private static string apiurl = "https://westeurope.api.cognitive.microsoft.com/face/v1.0";

    public APIKeys()
    {
	}

    public static string GetSubscriptionKey()
    {
        return subscriptionKey;
    }

    public static string getPersonGroupID()
    {
        return personGroupID;
    }

    public static string GetAPIURL()
    {
        return apiurl;
    }
}
