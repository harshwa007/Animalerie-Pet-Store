import "./home.scss";
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import petshop from "../../assests/images/petshop.jpg";
const Home = () => {
  const redirect = useNavigate();
  return (
<div className="home">
         <h1>Welcome to Animalerie</h1>
         <Button variant="outlined" color="primary" onClick={() => redirect("/products")}>
            Products List
         </Button>
         <img src={petshop} alt="petshop" />
      </div>
  )
}

export default Home