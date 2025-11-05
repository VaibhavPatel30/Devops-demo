import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {

  const [data, setData] = useState([]);
  const [error, setError] = useState("");
  const [productid, setProductid] = useState("");
  const [productidData, setProductidData] = useState([]);

  useEffect(() => {
    // API call to backend
    fetch(`${import.meta.env.VITE_API_URL}/get-products`)
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch");
        return res.json();
      })
      .then((result) => {
        setData(result.products);
        alert(result.message)
      })
      .catch((err) => {
        setError(err.message);
      });
  }, []);

  const fetchById = () => {
    fetch(`${import.meta.env.VITE_API_URL}/get-product-byid?id=${productid}`)
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch");
        return res.json();
      })
      .then((result) => {
        setProductidData(result);
      })
      .catch((err) => {
        setError(err.message);
      });
  }

  return (
    <>
      <h1>
        HELLO DOCKER 🐋
      </h1>

      {error && <p style={{ color: "red" }}>{error}</p>}

      <table border="1" cellPadding="10">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Price (₹)</th>
          </tr>
        </thead>
        <tbody>
          {data.map((p) => (
            <tr key={p.id}>
              <td>{p.id}</td>
              <td>{p.name}</td>
              <td>{p.price}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <input type="text" name="productid" value={productid} onChange={(e) => setProductid(e.target.value)} />
      <button onClick={() => fetchById()}>fetch</button>
      {productidData &&
        (
          <>
            <table border="1" cellPadding="10">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Name</th>
                  <th>Price (₹)</th>
                </tr>
              </thead>
              <tbody>
                <tr key={productidData.id}>
                  <td>{productidData.id}</td>
                  <td>{productidData.name}</td>
                  <td>{productidData.price}</td>
                </tr>
              </tbody>
            </table>
          </>
        )
      }
    </>
  )
}

export default App
