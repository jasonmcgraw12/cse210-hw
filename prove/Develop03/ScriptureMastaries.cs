using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class ScriptureMastaries
{
    Reference reference = new("Proverbs", 3, 5, 6);
    Reference reference1 = new("Isaiah", 1, 18);
    Reference reference2 = new("Joshua", 1, 8);
    Reference reference3 = new("1 Nephi", 3, 7);
    Reference reference4 = new("2 Nephi", 2, 25);
    Reference reference5 = new("Mosiah", 2, 17);
    Reference reference6 = new("Alma", 37, 6, 7);
    Reference reference7 = new("Helaman", 5, 12);
    Dictionary<Reference, string> referenceScriptures;


    public ScriptureMastaries()
    {
        referenceScriptures = new() {
        {reference,"Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths." }
        ,{reference1,"Come now, and let us reason together, saith the Lord: though your sins be as scarlet, they shall be as white as snow; though they be red like crimson, they shall be as wool." }
        ,{reference2,"This book of the law shall not depart out of thy mouth; but thou shalt meditate therein day and night, that thou mayest observe to do according to all that is written therein: for then thou shalt make thy way prosperous, and then thou shalt have good success." }
        ,{reference3,"I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them." }
        ,{reference4,"Adam fell that men might be; and men are, that they might have joy." }
        ,{reference5,"When ye are in the service of your fellow beings ye are only in the service of your God."}
        ,{reference6,"By small and simple things are great things brought to pass; and small means in many instances doth confound the wise."}
        ,{reference7,"And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation."}
    };
    }


    public KeyValuePair<Reference, string> GetReferenceAndScripture()
    {
        Random random = new();
        int randomIndex = random.Next(0, 8);
        KeyValuePair<Reference, string> referenceScripture = referenceScriptures.ElementAt(randomIndex);
        // Array array<Reference> = new object[] { referenceScripture.Key, referenceScripture.Value };
        return referenceScripture;
    }
}