namespace api
{
    public class Database
    {
        private string host {get; set;}
        private string database {get; set;}
        private string username {get; set;}
        private string port {get; set;}
        private string password {get; set;}

        public string cs {get; set;}

        public Database() {
            host = "ckshdphy86qnz0bj.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            database = "rloyazfcsagcdv36";
            username = "yawebagbp8e7u07m";
            port = "3306";
            password = "ldbjacf9xtnieqc4";

            cs = $"server = {host}; user = {username}; database = {database}; port = {port}; password = {password};";
        }
    }
}