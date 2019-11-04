using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.MemberContext
{
    public class Member : Entity<int>
    {
        public Member(
            int userId,
            int countryId,
            int cityId,
            int distrciId,
            bool isStudent,
            int universityId,
            int programId,
            bool isJob)
        {
            this.UserId = userId;
            this.CountryId = countryId;
            this.CityId = cityId;
            this.DistrictId = distrciId;
            this.IsStudent = IsStudent;
            this.UnversityId = universityId;
            this.ProgramId = programId;
            this.IsJob = isJob;
        }

        public int UserId { get; protected set; }
        public int CountryId { get; protected set; }
        public int CityId { get; protected set; }
        public int DistrictId { get; protected set; }
        public bool IsStudent { get; protected set; }
        public int UnversityId { get; protected set; }
        public int ProgramId { get; protected set; }
        public bool IsJob { get; protected set; }
    }
}
