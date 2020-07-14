using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TabimProje.Core.Model;

namespace TabimProje.Core.DataAccess.EntityFramework
    //Hepsine tek tek CRUD işlemi yapmak yerine tek seferde, kod tekrarını engelledik.
{
    //EFRespository Gelen tip IRepository'e gitmesi lazım o yüzden ikisinin Generic Tipi aynı olmalı
    // IRepository interface'i buraya implemente edilir. Yazılan interface generic olduğu için bu classta generic yazıyoruz. Bu sayede, RepositoryBase'e gelen tip IRepository'e de verilir. Aynı kısıt, burada da yazılmalıdır.
    //Bu bir core yapı olduğu için bütün projelere göre uyum sağlaması gerektiği için TContext göndererek her türlü veritabanını gönderebilir.Başka projelerde bu yapıyı kullanabiliyoruz..
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext, new()
    {//Bir DLL olduğu için RepositoryBase classına ayrıca context nesnesi de gönderilir.Bu sayede EF ile çalışırken içerisine context de gönderilir. 
     //Context nesnesinin ayrıca DbContext nesnesinden türemesi gerekir. Çünkü işlemler sadece context nesnesi ile yapılabilir. 
        TContext context;

        DbSet<TEntity> entities;//Burda daha modellerimiz oluşmadığı için Set metotunu kullanmamız gerekir.İlgili entity tipi ne ise onun metotlarını döndürür.
        public EFRepositoryBase()
        {

            //Singleton metot yaparak tek bir instance olarak almamızı sağladı.
            context = SingletonContext<TContext>.Context;

            entities = context.Set<TEntity>();
        }
        public int Add(TEntity entity)
        {
            try
            {
                entities.Add(entity);
                return context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Delete(TEntity entity)
        {
            entities.Remove(entity);
            return context.SaveChanges();
        }
        //Expression -> Lambda kullanmak için yazılan fonksiyon(a=>a.KullaniciId)
        //filtreleme sonucu true olanları getir gibi
        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {//params -> KUllanıcı bütün datalarını getirmiş oluyoruz..
            if (includes != null)
            {
                //İnclude metodu, SingleOrDefault seçili bir eleman gelsin, seçim sağlanmıyorsa bu durumda varsayılan degeri 0 döndür..
                return entities.IncludeMultiple(includes).SingleOrDefault(filter);
                
            }
            else
            {
                //SingleOrDefault metodu içerisine TEntity ve bool içeren bir filter ister.Gelen filter direk içerisine verilerek sorgulama yapılabilir.
                return entities.SingleOrDefault(filter);
            }
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            if (filter != null && includes != null)
            {
                //Where sorgusu filtreyi uygula anlamına gelir. Getirdiğim kullanıcıID=KULLANİCİID gibi bu filtreyi uygula..
                return entities.IncludeMultiple(includes).Where(filter).ToList();
                //Hem bir filtre parametresi hemde yanında navigation property(bağımlı tablo) gelmesi istenirse bu if'e girmiştir. 
            }
            else if (filter != null)
            {
                return entities.Where(filter).ToList();
            }
            else if (includes != null)
            {
                return entities.IncludeMultiple(includes).ToList();
            }
            else
            {
                return entities.ToList();
            }
        }

        public int Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
