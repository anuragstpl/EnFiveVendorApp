using EnFiveSales.DTO;
using EnFiveSales.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class VendorListViewModel : BaseViewModel
    {
        public ObservableCollection<UserDTO> UserDetails { get; set; }

        public VendorListViewModel()
        {
            UserDTO userDTO = new UserDTO();
            userDTO.Username = "anuragchaurasia";
            userDTO.StoreName = "Universal Mobile Shop";
            userDTO.Address = "Hardoi,Lucknow";
            UserDetails = new ObservableCollection<UserDTO>();
            UserDetails.Add(userDTO);
            Task.Run(async () => { await GetVendorData(); }).Wait();
        }

        public async Task<string> GetVendorData()
        {
            string work = "ToDo";
            //System.Json.JsonValue getUserDocResponse = await HttpRequestHelper<string>.GetRequest(ServiceTypes.GetAllUsers, SessionHelper.AccessToken);
            //GetUserDocResponse getUserDoc = JsonConvert.DeserializeObject<GetUserDocResponse>(getUserDocResponse.ToString());
            //if (getUserDoc.IsSuccess)
            //{
            //    List<UserDTO> lstDocument = getUserDoc.docList.Select(dc => new Document()
            //    {
            //        DocumentName = dc.DocumentName,
            //        AddedOn = dc.AddedOn,
            //        //AdminVisible = (bool)dc.AdminVisible,
            //        //AdminVisibleVal = dc.AdminVisibleVal,
            //        Description = dc.Description,
            //        DocumentID = dc.DocumentID,
            //        DocumentPath = dc.DocumentPath,
            //        DocumentTypeID = dc.DocumentTypeID,
            //        DocumentTypeName = dc.DocumentTypeName,
            //        FileFor = dc.FileFor,
            //        FileYear = dc.FileYear,
            //        //IsCompleteService = (bool)dc.IsCompleteService,
            //        //SalesVisible = (bool)dc.SalesVisible,
            //        ServiceID = dc.ServiceID,
            //        UserID = dc.UserID
            //    }).ToList();

            //    UserDetails = new ObservableCollection<UserDTO>();

            //    foreach (Document document in lstDocument)
            //    {
            //        DocumentsList.Add(document);
            //    }
            //}
            //else
            //{

            //}
            //return getUserDoc;
            return work;
        }
    }
}
