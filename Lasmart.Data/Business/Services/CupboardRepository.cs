using Lasmart.Data.Business.Interfaces;
using Lasmart.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasmart.Data.Business.Services
{
    class CupboardRepository : Repository<Cupboard>, ICupboardRepository
    {
        public CupboardRepository(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }

        public IEnumerable<Cupboard> GetAll()
        {
            if (this.Db is null)
                return RandomData();
            else
            {
                var returnData = new List<Cupboard>();
                try
                {
                    SqlCommand cmd = null;
                    string procedure = "";
                    cmd = new SqlCommand(procedure, this.Db);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    this.Db.Open();
                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        Cupboard cupboard = new Cupboard();
                        cupboard.Id= SqlHelper.GetSmallintFromReader(sqlReader, 0);
                        cupboard.Name = SqlHelper.GetStringFromReader(sqlReader, 1);

                        cupboard.Width = SqlHelper.GetDoubleFromReader(sqlReader, 2);
                        cupboard.Height = SqlHelper.GetDoubleFromReader(sqlReader, 3);
                        cupboard.Depth = SqlHelper.GetDoubleFromReader(sqlReader, 4);

                        cupboard.Image = SqlHelper.GetStringFromReader(sqlReader, 5);
                        returnData.Add(cupboard);
                    }
                }
                catch { }
                finally
                {
                    this.Db.Close();
                    this.Db.Dispose();
                }

                return returnData;
            }
            
        }

        private IEnumerable<Cupboard> RandomData()
        {
            return new List<Cupboard> {
                new Cupboard {
                    Id = 1,
                    Name = "Березовый шкаф",
                    Width = 24,
                    Height = 104,
                    Depth = 50,
                    Image = "berez.png"

                },
                new Cupboard {
                    Id = 2,
                    Name = "Дубовый шкаф",
                    Width = 24,
                    Height = 104,
                    Depth = 50,
                    Image = "dub.png"

                },
                new Cupboard {
                    Id = 3,
                    Name = "Черный шкаф",
                    Width = 24,
                    Height = 104,
                    Depth = 50,
                    Image = "black.png"

                }
            };
        }
    }
}
