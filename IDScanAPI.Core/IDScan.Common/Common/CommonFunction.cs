using System;
using System.Linq;
namespace Common
{
    /// <summary>
    /// Thia is this used for do all the common operation .
    /// </summary>
    public static class CommonFunction
    {
        #region Public Methods
        /// <summary>
        /// Get Status list for drop down 
        /// </summary>
        /// <returns></returns>
        public static dynamic GetStatusForDropDown()
        {

            var listStatus = Enum.GetValues(typeof(Enumaration.Status))
            .Cast<Enumaration.Status>().Select(x => new Status
            {
                Id = (int)x,
                Name = x.ToString()
            }).ToList();

            return listStatus;
        }

        /// <summary>
        /// Get Card Type List for drop down 
        /// </summary>
        /// <returns></returns>
        public static dynamic GetCardTypeForDropDown()
        {

            var listStatus = Enum.GetValues(typeof(Enumaration.CardType))
            .Cast<Enumaration.CardType>().Select(x => new CardType
            {
                CardId = (int)x,
                CardTypeName = x.ToString()
            }).ToList();

            return listStatus;
        }
        #endregion
       

        #region Helpers Classes
        private class Status
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        private class CardType
        {
            public int CardId { get; set; }
            public string CardTypeName { get; set; }
        }

        #endregion

    }
}
