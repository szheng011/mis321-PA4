namespace api.models
{
    public class Activity
    {
        public int activityID {get; set;}
        public string activityType {get; set;}
        public double distance {get; set;}
        public string dateCompleted {get; set;}
        public bool pinned {get; set;}
        public bool deleted {get; set;}
    }
}