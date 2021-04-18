using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HugoWorld_WCF.Services
{
    [ServiceContract]
    public interface ITileImgService
    {
        [OperationContract]
        Models.TileImport MonstreToTile(DTOs.MonstreDTO monstre);

        [OperationContract]
        Models.TileImport ItemToTile(DTOs.ItemDTO item);

        [OperationContract]
        Models.TileImport ObjetMondeToTile(DTOs.ObjetMondeDTO objet);
    }
}
