using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
    public class Messages
    {
        public static string CarAdded = "Successfully added car ";
        public static string InvalidCarAdded = "Sorry, cannot add car ";
        public static string CarDeleted = "Successfully deleted car ";
        public static string CarUpdated = "Successfully updated car ";
        public static string CarListed = "Cars are listed";
        public static string CarById = "Car is here";

        public static string ColorAdded = "Successfully added color ";
        public static string ColorDeleted = "Successfully deleted color ";
        public static string ColorUpdated = "Successfully updated color ";
        public static string ColorListed = "Colors are listed";
        public static string ColorById = "Color is here";

        public static string BrandAdded = "Successfully added brand ";
        public static string BrandDeleted = "Successfully deleted brand ";
        public static string BrandUpdated = "Successfully updated brand ";
        public static string BrandListed = "Brands are listed";
        public static string BrandById = "Brand is here";

        public static string UserAdded = "Successfully added user ";
        public static string UserDeleted = "Successfully deleted user ";
        public static string UserUpdated = "Successfully updated user ";
        public static string UserListed = "Users are listed";

        public static string CustomerAdded = "Successfully added customer ";
        public static string CustomerDeleted = "Successfully deleted customer ";
        public static string CustomerUpdated = "Successfully updated customer ";
        public static string CustomerList = "Customers are listed";

        public static string RentalDeleted = "Successfully deleted rental ";
        public static string RentalUpdated = "Successfully updated rental ";
        public static string InvalidRental = "This car is not currently available";
        public static string RentalAdded = "This car is available now. Car rental successful";
        public static string RentalListed = "Rentals are listed";

        public static string UserExists = "User already exists to system";
        public static string UserNotFound = "User not found to system";
        public static string BadPassword = "Entered the not correct password";
        public static string NotBeAuth = "You are not authorized";

        public static string SameBrandCarsCountExceeded = "The number of car with the same brand is too many, you cannot add car of this brand";

        public static string CreditCardAdded = "Successfully added credit card ";
        public static string CreditCarDeleted = "Successfully deleted credit card ";
        public static string CreditCardUpdated = "Successfully updated credit card ";
    }
}
