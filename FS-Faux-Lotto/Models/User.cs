namespace FS_Faux_Lotto.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FireBaseId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Email { get; set; }
        public string ImageLocation { get; set; }
        public int Currency { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}