namespace designPatterns.model.Behavioural
{
    public class HandlerWindowModel : WindowModel
    {

        public HandlerWindowModel(string desc) : base(desc) {
        }

        public override void Run() {
            Member dung = new Director();
            Member phuong = new ViceDirector();
            Member huy = new ProjectManager();

            huy.HigherMember = phuong;
            phuong.HigherMember = dung;
    
            var job = new Job("Easy job for noob", (float) 50.0);
            huy.Process(job);

            var job1 = new Job("Big job", (float) 2000.0);
            huy.Process(job1);

            var job2 = new Job("Normal job", (float) 350.0);
            huy.Process(job2);
        }
    }

    #region Handler pattern code behind the scene

    /// <summary>
    /// abstract class representing all company member
    /// </summary>
    public abstract class Member {
        
        protected float LimitedPrice;
        public Member HigherMember { get; set; }

        /// <summary>
        /// Process an incoming job
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public virtual string Process(Job job) {
            if (job.Price < LimitedPrice) {
                var output = "##Processing job: " + System.Environment.NewLine;
                output += "Description: " + job.Description + System.Environment.NewLine;
                output += "Price: " + job.Price + System.Environment.NewLine;
                return output;
            }
            return HigherMember.Process(job);
        }
    }

    /// <summary>
    /// Director 
    /// </summary>
    public class Director: Member {
        public Director() {
            LimitedPrice = float.MaxValue;
        }
    }

    /// <summary>
    /// Vice Director
    /// </summary>
    public class ViceDirector : Member {
        public ViceDirector() {
            LimitedPrice = 500;
        }
    }

    /// <summary>
    /// Project Manager
    /// </summary>
    public class ProjectManager: Member {
        public ProjectManager() {
            LimitedPrice = 200;
        }
    }

    public class Job {
        public string Description { get; set; }
        public float Price { get; set; }

        public Job(string description, float price) {
            Description = description;
            Price = price;
        }
    }

    #endregion
}
