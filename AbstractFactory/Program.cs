using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IMobilePhone nokia = new Nokia();
            MobileClient nokiaClient = new MobileClient(nokia);

            Console.WriteLine("*****************NOKIA********************");
            Console.WriteLine(nokiaClient.GetNormalPhoneDetails());
            Console.WriteLine(nokiaClient.GetSmartPhoneDetails());
        }
    }

    class MobileClient
    {
        ISmartPhone smartPhone;
        INormalPhone normalPhone;
        public MobileClient(IMobilePhone mobilePhone)
        {
            smartPhone = mobilePhone.GetSmartPhone();
            normalPhone = mobilePhone.GetNormalPhone();
        }

        public string GetSmartPhoneDetails()
        {
            return smartPhone.GetModelDetails();
        }

        public string GetNormalPhoneDetails()
        {
            return normalPhone.GetModelDetails();
        }
    }

    interface INormalPhone
    {
        string GetModelDetails();
    }

    interface ISmartPhone
    {
        string GetModelDetails();
    }

    class NokiaPixel : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "This is nokia pixel smartphone";
        }
    }

    class SamSungGalaxy : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "This is samsung Galaxy Smartphone";
        }
    }

    class Nokia1600 : INormalPhone
    {
        public string GetModelDetails()
        {
            return "This is Nokia1600 Normal phone.";
        }
    }

    class SamsungGuru : INormalPhone
    {
        public string GetModelDetails()
        {
            return "This Samsung Guru Normal phone";
        }
    }

    interface IMobilePhone
    {
        ISmartPhone GetSmartPhone();
        INormalPhone GetNormalPhone();
    }

    class Nokia : IMobilePhone
    {
        public INormalPhone GetNormalPhone()
        {
            return new Nokia1600();
        }

        public ISmartPhone GetSmartPhone()
        {
            return new NokiaPixel();
        }
    }

    class Samsung : IMobilePhone
    {
        public INormalPhone GetNormalPhone()
        {
            return new SamsungGuru();
        }

        public ISmartPhone GetSmartPhone()
        {
            return new SamSungGalaxy();
        }
    }
}
