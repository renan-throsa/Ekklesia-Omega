using System;

namespace Ekklesia.Entities.Entities
{
    public class OccasionMember
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int OccasionId { get; set; }
        public Occasion Occasion { get; set; }        
        
        public override bool Equals(object? obj)
        {
            OccasionMember? occasionMember = obj as OccasionMember;

            if (occasionMember == null)
            {
                return false;
            }
            return this.MemberId.Equals(occasionMember.MemberId) &&
                this.OccasionId.Equals(occasionMember.OccasionId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MemberId, OccasionId);
        }
    }
}
