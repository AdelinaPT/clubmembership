using clubmembership.Data;
using clubmembership.Models.DBObjects;
using clubmembership.Models;

namespace clubmembership.Repository
{
    public class MembershipTypeRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public MembershipTypeRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public MembershipTypeRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private MembershipTypeModel MapDBObjectToModel(MembershipType dbobject)
        {
            var model = new MembershipTypeModel();
            if (dbobject != null)
            {
                model.IdmembershipType = dbobject.IdmembershipType;
                model.Name = dbobject.Name;
                model.Description = dbobject.Description;
                model.SubscriptionLenghtInMonths = dbobject.SubscriptionLenghtInMonths;
            }
            return model;
        }

        private MembershipType MapModelToDBObject(MembershipTypeModel model)
        {
            var dbobject = new MembershipType();
            if (model != null)
            {
                dbobject.IdmembershipType = model.IdmembershipType;
                dbobject.Name = model.Name;
                dbobject.Description = model.Description;
                dbobject.SubscriptionLenghtInMonths = model.SubscriptionLenghtInMonths;

            }
            return dbobject;
        }

        public List<MembershipTypeModel> GetAllMembershipTypes()
        {
            var list = new List<MembershipTypeModel>();
            foreach (var dbobject in _DBContext.MembershipTypes)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public MembershipTypeModel GetMembershipTypeById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.MembershipTypes.FirstOrDefault(x => x.IdmembershipType == id));
        }

        public void InsertMembershipType(MembershipTypeModel model)
        {
            model.IdmembershipType = Guid.NewGuid();
            _DBContext.MembershipTypes.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();

        }

        public void UpdateMembershipType(MembershipTypeModel model)
        {
            var dbobject = _DBContext.MembershipTypes.FirstOrDefault(x => x.IdmembershipType == model.IdmembershipType);
            if (dbobject != null)
            {
                dbobject.IdmembershipType = model.IdmembershipType;
                dbobject.Name = model.Name;                
                dbobject.Description = model.Description;
                dbobject.SubscriptionLenghtInMonths = model.SubscriptionLenghtInMonths;               
                _DBContext.SaveChanges();
            }

        }
                
        public void DeleteMembershipType(MembershipTypeModel model)
        {
            var dbObject = _DBContext.MembershipTypes.FirstOrDefault(x => x.IdmembershipType == model.IdmembershipType);
            if (dbObject != null)
            {
                var memberships = _DBContext.Memberships.Where(x => x.IdmembershipType == model.IdmembershipType);
                foreach (var membership in memberships)
                {
                    _DBContext.Memberships.Remove(membership);
                }
            }
            _DBContext.MembershipTypes.Remove(dbObject);
            _DBContext.SaveChanges();
        }
    }
}
