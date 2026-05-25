using System.Reflection.Metadata.Ecma335;
using FeedbackApp.Models;

namespace FeedbackApp.Service
{
    public class FeedbackService
    {
        private List<Feedback> feedbackList;

        public void AddFeedback(Feedback objFeedback)
        {
            if (feedbackList == null)
            {
                feedbackList = new ();
            }
            feedbackList.Add(objFeedback);
        }

        public IEnumerable<Feedback> GetFeedback() => feedbackList;
    }
}