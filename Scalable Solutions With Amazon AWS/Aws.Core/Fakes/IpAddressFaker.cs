namespace Aws.Core.Fakes
{
    public static class IpAddressFaker
    {
        public static string IpAddress()
        {
            return string.Format("{0}.{1}.{2}.{3}",
                Faker.NumberFaker.Number(0, 255),
                Faker.NumberFaker.Number(0, 255),
                Faker.NumberFaker.Number(0, 255),
                Faker.NumberFaker.Number(0, 255)
            );
        }
    }
}