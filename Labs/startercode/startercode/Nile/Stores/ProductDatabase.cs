/* 
 * Student: Chau Trinh
 * Class: ITSE 1430
 * Lab 4: Nile
 * Date: 19 Nov 2018
 */
using System;
using System.Collections.Generic;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            //TODO: Check arguments
            //Check null
            if (product == null)
                throw new ArgumentNullException("product");
            //Check invalid 
                
            if (product.Name == null)
                throw new ArgumentNullException("name");
            else if (product.Name == "")
                throw new ArgumentException("Name cannot be empty");

            //Throw exception when adding a product with same name 

            //var existing = GetCore(product.Id);
            //if (!(String.IsNullOrEmpty(existing.Name)))
            //{
            //    if (String.Compare(product.Name, existing.Name, true) == 0)
            //        throw new ArgumentNullException("This product already added.");
            //}

            if (product.Price < 0)
                throw new ArgumentOutOfRangeException("Price must be greater or equal to 0");

            //TODO: Validate product
            ObjectValidator.Validate(product);


            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            //TODO: Check arguments
            if (id < 0 )
                throw new ArgumentOutOfRangeException("ID is invalid.");

            var existing = GetCore(id);
            if (existing == null)
                throw new Exception("Product not found.");

            return GetCore(id);
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            //TODO: Check arguments
            if (id < 0)
                throw new ArgumentOutOfRangeException("ID is invalid.");

            var existing = GetCore(id);
            if (existing == null)
                throw new Exception("Product not found.");

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            //TODO: Check arguments
                //Check null
            if (product == null)
                throw new ArgumentNullException("product");
                //Check invalid 
            if (product.Name == null)
                throw new ArgumentNullException("name");
            else if (product.Name == "")
                throw new ArgumentException("Name cannot be empty");

            if (product.Price < 0)
                throw new ArgumentOutOfRangeException("Price must be greater or equal to )");
   
            //TODO: Validate product
            ObjectValidator.Validate(product);

            //Get existing product
            var existing = GetCore(product.Id);
            if (existing == null)
                throw new Exception("Product not found.");

            //Update product to a new name that already exists, fails
            
            //if (product.Name != existing.Name && product.Name == GetCore(product.Id).Name)
            //    throw new ArgumentException("This product already added");



            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );

        protected abstract Product FindProduct( int id );
        #endregion
    }
}
