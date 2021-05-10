using System.ServiceModel;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface ITileImgService {

        [OperationContract]
        Models.TileImport MonstreToTile(DTOs.MonstreDTO monstre);

        [OperationContract]
        Models.TileImport ItemToTile(DTOs.ItemDTO item);

        [OperationContract]
        Models.TileImport ObjetMondeToTile(DTOs.ObjetMondeDTO objet);

        [OperationContract]
        Models.TileImport GetTileAt(int x, int y, int mondeId);
    }
}