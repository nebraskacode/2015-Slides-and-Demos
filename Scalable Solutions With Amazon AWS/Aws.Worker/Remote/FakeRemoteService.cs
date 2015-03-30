using System;

namespace Aws.Worker.Remote
{
    /// <summary>
    /// This class represents some fake service. If enough time has passed after GetData() some data will be returned
    /// </summary>
    public class FakeRemoteService : IRemoteService
    {
        private DateTime lastRequest = DateTime.Now;
        private readonly int delay = new Random().Next(10, 20);

        public bool HasData()
        {
            return DateTime.Now > lastRequest.AddSeconds(delay);
        }

        public string GetData()
        {
            if (HasData())
            {
                lastRequest = DateTime.Now;
                return Faker.StringFaker.AlphaNumeric(4).ToUpper();
            }
            return null;
        }
    }
}