namespace Stefanini.Challenge.Domain.Dtos.Response.Person
{
    public class PersonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Age { get; set; }
        public int CityId { get; set; }
        public Entities.City City { get; set; }
    }
}
