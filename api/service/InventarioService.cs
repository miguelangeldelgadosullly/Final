using model;
using Persisten;
using System;
using System.Collections.Generic;
using System.Linq;

namespace service
{public interface InvenService
    {
        IEnumerable<Inventario> GetAll( );
       
        bool Add(Inventario model);
        bool Delete(int id);
        bool Update(Inventario model);
         Inventario Get(int id);
    }
    
    public class InventarioService : InvenService
    {
        private readonly InvenDbContext _invenDbContext;

      
        public InventarioService(
            InvenDbContext InvenDbContext)
        {

            _invenDbContext = InvenDbContext;



        }

        public IEnumerable<Inventario> GetAll( )
        {

            var result = new List<Inventario>();

            try
            {
                result = _invenDbContext.Inventario.ToList();
            }
            catch (Exception)
            {


            }

            return result;




        }
        public Inventario Get(int  id)
        {

            var result = new Inventario();

            try
            {
                result = _invenDbContext.Inventario.Single(X => X.Id == id);
            }
            catch (Exception)
            {


            }

            return result;




        }

        public bool Add(Inventario model)
        {

            

            try
            {
                _invenDbContext.Add( model);
                _invenDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;




        }


       

        public bool Update(Inventario model)
        {



            try
            {
                var originalModel = _invenDbContext.Inventario.Single(X => X.Id == model.Id);

                originalModel.Nombre = model.Nombre;
                originalModel.Fecha = model.Fecha;
                originalModel.Precio = model.Precio;
                originalModel.Proveedor = model.Proveedor;



                _invenDbContext.Update(model);
                _invenDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

            public bool Delete(int id)
        {



            try
            {
                _invenDbContext.Entry(new Inventario {Id = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted ;
                _invenDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;




        }

    }
}
