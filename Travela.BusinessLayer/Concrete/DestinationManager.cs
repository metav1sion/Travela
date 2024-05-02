using Travela.BusinessLayer.Abstract;
using Travela.DataAccessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.BusinessLayer.Concrete;

public class DestinationManager : IDestinationService
{
    private readonly IDestinationDal _dal;

    public DestinationManager(IDestinationDal dal)
    {
        _dal = dal;
    }

    public void TInsert(Destination entity)
    {
        _dal.Insert(entity);
    }

    public void TUpdate(Destination entity)
    {
        _dal.Update(entity);
    }

    public void TDelete(int id)
    {
        _dal.Delete(id);
    }

    public Destination TGetByID(int id)
    {
        return _dal.GetByID(id);
    }

    public List<Destination> TGetListAll()
    {
        return _dal.GetListAll();
    }
}