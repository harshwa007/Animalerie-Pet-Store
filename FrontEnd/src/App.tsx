import React from "react";
import Navbar from "./Components/Navbar/Navbar";
import { Route, Routes } from "react-router-dom";
import Home from "./pages/home/Home.page";
import Products from "./pages/products/product.page";
import EditProduct from "./pages/edit-product/EditProduct.page";
import AddProduct from "./pages/add-product/AddProduct.page";
import DeleteProduct from "./pages/delete-product/DeleteProduct.page";
// import { Home } from "@mui/icons-material";
const App: React.FC = () => {
  return (
    <div>
      {/* Navbar */}
      <Navbar></Navbar>
      {/* Wrapper */}
      <div className="Wrappeer">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/products">
              <Route index element={<Products/>} />
              <Route path="add" element={<AddProduct />} />
                  <Route path="edit/:id" element={<EditProduct />} />
                  <Route path="delete/:id" element={<DeleteProduct />} />
          </Route>
        </Routes>
      </div>
    </div>
  );
};

export default App;
