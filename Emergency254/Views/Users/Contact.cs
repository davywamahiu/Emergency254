using System.Text;
using System.Text.Json.Serialization;

using Emergency254.Shared.Interfaces;
using MvvmHelpers;

namespace Emergency254.Shared.Models
{
    public class Contact : ObservableObject, IContact
    {
        public string DataPartitionId { get; set; } = string.Empty;

        string id = string.Empty;
        [JsonPropertyName("id")]
        public string Id 
        { 
            get => id;
            set => SetProperty(ref id, value); 
        }

        string nhif = string.Empty;
        [JsonPropertyName("nhif")]
        public string Nhif
        {
            get => nhif;
            set => SetProperty(ref nhif, value);
        }

        string firstName = string.Empty;
        [JsonPropertyName("firstName")]
        public string FirstName
        {
            get => firstName;
            set
            {
                SetProperty(ref firstName, value);
                // DisplayName is dependent on FirstName
                OnPropertyChanged(nameof(DisplayName));
                // DisplayLastNameFirst is dependent on FirstName
                OnPropertyChanged(nameof(DisplayLastNameFirst));
            }
        }

        string lastName = string.Empty;
        [JsonPropertyName("lastName")]
        public string LastName
        {
            get => lastName;
            set
            {
                SetProperty(ref lastName, value);
                // DisplayName is dependent on LastName
                OnPropertyChanged(nameof(DisplayName));
                // DisplayLastNameFirst is dependent on LastName
                OnPropertyChanged(nameof(DisplayLastNameFirst));
            }
        }

        string company = string.Empty;
        [JsonPropertyName("company")]
        public string Company
        {
            get => company;
            set => SetProperty(ref company, value);
        }

        string jobTitle = string.Empty;
        [JsonPropertyName("jobTitle")]
        public string JobTitle
        {
            get => jobTitle;
            set => SetProperty(ref jobTitle, value);
        }

        string email = string.Empty;
        [JsonPropertyName("email")]
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        string phone = string.Empty;
        [JsonPropertyName("phone")]
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        string street = string.Empty;
        [JsonPropertyName("street")]
        public string Street
        {
            get => street;
            set
            {
                SetProperty(ref street, value);
                // AddressString is dependent on Street
                OnPropertyChanged(nameof(AddressString));
            }
        }

        string city = string.Empty;
        [JsonPropertyName("city")]
        public string City
        {
            get => city;
            set
            {
                SetProperty(ref city, value);
                // AddressString is dependent on City
                OnPropertyChanged(nameof(AddressString));
            }
        }

        string postalCode = string.Empty;
        [JsonPropertyName("postalCode")]
        public string PostalCode
        {
            get => postalCode;
            set
            {
                SetProperty(ref postalCode, value);
                // AddressString is dependent on PostalCode
                OnPropertyChanged(nameof(AddressString));
                // StatePostal is dependent on PostalCode
                OnPropertyChanged(nameof(StatePostal));
            }
        }

        

        string state = string.Empty;
        [JsonPropertyName("state")]
        public string State
        {
            get => state;
            set
            {
                SetProperty(ref state, value);
                // AddressString is dependent on State
                OnPropertyChanged(nameof(AddressString));
                // StatePostal is dependent on State
                OnPropertyChanged(nameof(StatePostal));
            }
        }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; } = 0;

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; } = 0;


        string photoUrl= "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg";
        [JsonPropertyName("photoUrl")]
        public string PhotoUrl
        {
            get => photoUrl;
            set
            {
                SetProperty(ref photoUrl, value);
                // SmallPhotoUrl is dependent on PhotoUrl
                OnPropertyChanged(nameof(SmallPhotoUrl));
            }
        }

        public string SmallPhotoUrl => PhotoUrl;

        [JsonIgnore]
        public string AddressString => string.Format(
            "{0} {1} {2} {3}",
            Street,
            !string.IsNullOrWhiteSpace(City) ? City + "," : "",
            State,
            PostalCode);

        [JsonIgnore]
        public string DisplayName => ToString();

        [JsonIgnore]
        public string DisplayLastNameFirst => $"{LastName}, {FirstName}";

        [JsonIgnore]
        public string StatePostal => State + " " + PostalCode;
      
        public override string ToString() => $"{FirstName} {LastName}";

        
        string uniqueCodeUser = string.Empty;
        [JsonPropertyName("uniqueCodeUser ")]
        public string UniqueCodeUser
    {
            get => uniqueCodeUser;
            set => SetProperty(ref uniqueCodeUser, value);
        }
        public byte[] Image { get; set; }
        [JsonIgnore]
        public bool hasPicture
        {
            get
            {
                return this.Image != null;
            }
        }

    }
}

