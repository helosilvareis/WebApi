namespace WebApi.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }

        public UserModel()
        {

        }

        public UserModel(int ID, string Name, string Login)
        {
            this.ID = ID;
            this.Name = Name;
            this.Login = Login;
        }
    }
}