using clubmembership.Data;
using clubmembership.Models.DBObjects;
using clubmembership.Models;

namespace clubmembership.Repository
{
    public class MembershipRepository
    {
        //private readonly ApplicationDbContext _DBContext;
        //public MembershipRepository()
        //{
        //    _DBContext = new ApplicationDbContext();
        //}

        //public MembershipRepository(ApplicationDbContext dBContext)
        //{
        //    _DBContext = dBContext;
        //}

        //private MembershipModel MapDBObjectToModel(Membership dbobject)
        //{
        //    var model = new MembershipModel();
        //    if (dbobject != null)
        //    {
        //        model.Idmember = dbobject.Idmember;
        //        model.Name = dbobject.Name;
        //        model.Title = dbobject.Title;
        //        model.Position = dbobject.Position;
        //        model.Description = dbobject.Description;
        //        model.Resume = dbobject.Resume;
        //    }
        //    return model;
        //}

        //private Membership MapModelToDBObject(MembershipModel model)
        //{
        //    var dbobject = new Member();
        //    if (model != null)
        //    {
        //        dbobject.Idmember = model.Idmember;
        //        dbobject.Name = model.Name;
        //        dbobject.Title = model.Title;
        //        dbobject.Position = model.Position;
        //        dbobject.Description = model.Description;
        //        dbobject.Resume = model.Resume;
        //    }
        //    return dbobject;
        //}

        //public List<MembershipModel> GetAllMemberships()
        //{
        //    var list = new List<MembershipModel>();
        //    foreach (var dbobject in _DBContext.Memberships)
        //    {
        //        list.Add(MapDBObjectToModel(dbobject));
        //    }
        //    return list;
        //}

        //public MembershipModel GetMembershipById(Guid id)
        //{
        //    return MapDBObjectToModel(_DBContext.Memberships.FirstOrDefault(x => x.Idmember == id));
        //}

        //public void InsertMembership(MembershipModel model)
        //{
        //    model.Idmember = Guid.NewGuid();
        //    _DBContext.Memberships.Add(MapModelToDBObject(model));
        //    _DBContext.SaveChanges();

        //}

        //public void UpdateMembership(MembershipModel model)
        //{
        //    var dbobject = _DBContext.Memberships.FirstOrDefault(x => x.Idmember == model.Idmember);
        //    if (dbobject != null)
        //    {
        //        dbobject.Idmember = model.Idmember;
        //        dbobject.Name = model.Name;
        //        dbobject.Title = model.Title;
        //        dbobject.Position = model.Position;
        //        dbobject.Description = model.Description;
        //        dbobject.Resume = model.Resume;
        //        _DBContext.SaveChanges();
        //    }

        //}

        //public void DeleteMembershipr(MembershipModel model)
        //{
        //    var dbobject = _DBContext.Memberships.FirstOrDefault(x => x.Idmember == model.Idmember);
        //    if (dbobject != null)
        //    {
        //        _DBContext.Memberships.Remove(dbobject);

        //        _DBContext.SaveChanges();
        //    }
        //}
    }
}
