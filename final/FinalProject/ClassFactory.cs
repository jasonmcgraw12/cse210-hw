using Microsoft.VisualBasic;

static class ClassFactory
{
    // Name -> Type -> returned class casted as Object
    // Because of the way this function is set up I need to cast it afterwards
    public static Object MakeClass(string classID)
    {
        var type = Type.GetType(classID);
        return Activator.CreateInstance(type);
    }

    public static string GetClassName(Type classType)
    {
        return classType.Name;
    }

    // static VariantType MakeClass(string classID)
    // {
    //     var createdObject = VariantType.Empty;
    //     switch (classID)
    //     {
    //         case "goblin":
    //             createdObject = new Goblin();
    //             break;
    //     }
    //     return createdObject;
    // }
    // static Goblin makeGoblin()
    // {
    //     return new Goblin();
    // }
}