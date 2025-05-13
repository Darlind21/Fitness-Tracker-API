using Fitness_Tracker_API.DataLayer.Models;

namespace Fitness_Tracker_API.BusinessLayer.Infrastructure
{
    public interface IBodyMeasurementService
    {
        public BodyMeasurement CreateBodyMeasurement();
        public BodyMeasurement GetBodyMeasurementById(int id);
        public BodyMeasurement GetBodyMeasurementByTimePeriod(DateOnly startDate, DateOnly endDate);
        public List<BodyMeasurement> GetAllBodyMeasurements();
        public void EditBodyMeasurement(int id);
        public void DeleteBodyMeasurement(int id);
    }
}
