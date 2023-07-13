namespace shoppingAPI.Models
{
	public class Products
	{
		//pId, pName, pCategory, pPrice, pDescription, pIsInStock
		#region Properties
		public int pId { get; set; }

		public string pName { get; set; }

		public string pCategory { get; set; }
		public double pPrice { get; set; }

		public string pDescription { get; set; }

		public bool pIsInStock { get; set; }
		

		#endregion
		#region Data

		private static int prd_autoNo = 0;

		public Products()
		{
			prd_autoNo = prd_autoNo + 1;
			this.pId = prd_autoNo;
		}

		private static List<Products> pList = new List<Products>()
			{
				new Products(){ pName="Kitkat", pCategory="Choculate", pPrice=200,  pDescription="Sales",    pIsInStock=true },
				new Products(){ pName="dairymilk", pCategory="Choculate", pPrice=100,   pDescription="Sales", pIsInStock=true } ,
				new Products(){ pName="milkybar", pCategory="Choculate", pPrice=120, pDescription="Sales",    pIsInStock=false   },
				new Products(){ pName="fivestar", pCategory="Choculate", pPrice=200, pDescription="Sales",    pIsInStock=true   },
				new Products(){ pName="munch", pCategory="Choculate", pPrice=150, pDescription="Sales", pIsInStock=true },
				new Products(){ pName="oreo", pCategory="Biscuit", pPrice=100,  pDescription="Sales", pIsInStock=true } ,
				new Products(){ pName="Dark Fantacy", pCategory="Biscuit", pPrice=120, pDescription="Sales",    pIsInStock=false   },
				new Products(){ pName="Kiran", pCategory="Biscuit", pPrice=200, pDescription="Sales",    pIsInStock=true    },
				new Products(){ pName="apple", pCategory="fruit", pPrice=100, pDescription="Sales", pIsInStock=true },
				new Products(){ pName="mango", pCategory="fruit",pPrice=180, pDescription="Sales",    pIsInStock=false   },
			};
		#endregion
		#region Methods

		#region Get Methods
		public List<Products> GetAllProducts()
		{
			return pList;
		}
		public List<Products> GetProductsByName(string name)
		{
			var prd = pList.FindAll(p => p.pName == name);
			if (prd != null)
			{
                return prd;
			}
            throw new Exception("pIsInStock Not Found");
        }

        public List<Products> GetProductsByCategory(string category)
		{
			var prd = pList.FindAll(p => p.pCategory == category);
			if (prd != null)
			{
                return prd;
            }
			throw new Exception("pIsInStock Not Found");
		}
		public List<Products> GetinStockProducts(bool state)
		{
			var prd = pList.FindAll(p => p.pIsInStock == state);
			return prd;
		}
		//public int GetTotalProducts()
		//{
		//	var total = pList.Count;
		//	return total;
		//}
		#endregion

		#region Add, update and delete
		public string AddProducts(Products newPrdObj)
		{
			pList.Add(newPrdObj);
			return "Products Added to list, new Product number is : " + newPrdObj.pId;
		}

		public string UpdateProduct(int id, Products prdObj)
		{
			var prd = pList.Find(p => p.pId == id);

			if (prd != null)
			{
				prd.pName = prdObj.pName;
				prd.pCategory = prdObj.pCategory;
				prd.pPrice = prdObj.pPrice;
				prd.pDescription = prdObj.pDescription;
				prd.pIsInStock = prdObj.pIsInStock;

				return "Product Updated";
			}
			return "product not Found, update failed";
		}
		public string DeleteProduct(int id)
		{
			var prd = pList.Find(p => p.pId == id);
			if (prd != null)
			{
				pList.Remove(prd);
				return "Product Deleted";
			}
			throw new Exception("Product Not Found");

		}
		#endregion
		private static List<Products> cart = new List<Products>();
		public List<Products> GetProductsCartById(int id)
		{
			var prd = pList.Find(pObj => pObj.pId == id);
			if (prd == null)
				throw new Exception("Product Not Found");
			cart.Add(prd);
			return cart;
		}

        public List<Products> GetAllCartProducts()
        {
            return cart;
        }

        #endregion
    }
}

