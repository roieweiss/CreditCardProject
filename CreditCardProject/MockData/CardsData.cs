using System;
using System.Collections.Generic;
using CreditCardProject.Models;

namespace CreditCardProject.MockData
{
    public class CardsData
    {
        public static readonly List<Cards> Cards = new List<Cards>
        {
            new Cards(
                name : "John Doe",
                cardNumber: 5326092299089923,
                validDate: new DateTime(2022, 12, 1),
                cardImage: "card14.jpg",
                isBlocked: false,
                isDigital: true,
                cardLimit: 50000,
                bankCode: 19
            ),
            new Cards(
                name : "Jane Smith",
                cardNumber: 5326560887036212,
                validDate: new DateTime(2022, 11, 1),
                cardImage: "card15.jpg",
                isBlocked: true,
                isDigital: false,
                cardLimit: 30000,
                bankCode: 12
            ),
            new Cards(
                name : "Alice Johnson",
                cardNumber: 5326543209045243,
                validDate: new DateTime(2022, 10, 1),
                cardImage: "card16.jpg",
                isBlocked: false,
                isDigital: true,
                cardLimit: 40000,
                bankCode: 17
            ),
            new Cards(
                name : "Bob White",
                cardNumber: 5326132592846211,
                validDate: new DateTime(2022, 9, 1),
                cardImage: "card17.jpg",
                isBlocked: true,
                isDigital: false,
                cardLimit: 35000,
                bankCode: 14
            ),
            new Cards(
                name : "Emily Brown",
                cardNumber: 5326890989098909,
                validDate: new DateTime(2022, 8, 1),
                cardImage: "card18.jpg",
                isBlocked: false,
                isDigital: true,
                cardLimit: 45000,
                bankCode: 12
            ),
            new Cards(
                name : "Michael Davis",
                cardNumber: 5326230987961426,
                validDate: new DateTime(2022, 7, 1),
                cardImage: "card19.jpg",
                isBlocked: true,
                isDigital: false,
                cardLimit: 30000,
                bankCode: 12
            ),
            new Cards(
                name : "Emma Wilson",
                cardNumber: 5326678967896789,
                validDate: new DateTime(2022, 6, 1),
                cardImage: "card20.jpg",
                isBlocked: false,
                isDigital: true,
                cardLimit: 40000,
                bankCode: 17
            ),
            new Cards(
                name : "William Taylor",
                cardNumber: 5326123712371237,
                validDate: new DateTime(2022, 5, 1),
                cardImage: "card21.jpg",
                isBlocked: true,
                isDigital: false,
                cardLimit: 35000,
                bankCode: 21
            ),
            new Cards(
                name : "Olivia Evans",
                cardNumber: 5326459035286961,
                validDate: new DateTime(2022, 4, 1),
                cardImage: "card22.jpg",
                isBlocked: false,
                isDigital: true,
                cardLimit: 50000,
                bankCode: 19
            ),
            new Cards(
                name : "Daniel Wilson",
                cardNumber: 5326567812111214,
                validDate: new DateTime(2022, 3, 1),
                cardImage: "card23.jpg",
                isBlocked: true,
                isDigital: false,
                cardLimit: 30000,
                bankCode: 12
            ),
            new Cards(
                name : "Sophia Clark",
                cardNumber: 5326543219876543,
                validDate: new DateTime(2022, 2, 1),
                cardImage: "card24.jpg",
                isBlocked: false,
                isDigital: true,
                cardLimit: 40000,
                bankCode: 17
            ),
            new Cards(
                name : "Matthew Anderson",
                cardNumber: 5326456135227890,
                validDate: new DateTime(2022, 1, 1),
                cardImage: "card25.jpg",
                isBlocked: false,
                isDigital: true,
                cardLimit: 50000,
                bankCode: 19
            ),
            new Cards(
                name : "Ava Martinez",
                cardNumber: 5326567812342278,
                validDate: new DateTime(2021, 12, 1),
                cardImage: "card26.jpg",
                isBlocked: true,
                isDigital: false,
                cardLimit: 30000,
                bankCode: 12
            ),
            new Cards(
                name : "Liam Hernandez",
                cardNumber: 5326543219876543,
                validDate: new DateTime(2021, 11, 1),
                cardImage: "card27.jpg",
                isBlocked: false,
                isDigital: true,
                cardLimit: 40000,
                bankCode: 17
            ),
            new Cards(
                name : "Charlotte Thompson",
                cardNumber: 5326456745674567,
                validDate: new DateTime(2021, 10, 1),
                cardImage: "card28.jpg",
                isBlocked: true,
                isDigital: false,
                cardLimit: 35000,
                bankCode: 14
            )
        };
    }
}
