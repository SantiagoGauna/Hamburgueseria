import { useEffect, useState } from "react";
import * as React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";

const PedidosPage = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
      
        // Reparar esta llamada al endpoint correspondiente
        const response = await fetch("https://localhost:44349/Pedido");

        // Parseo la respuesta a JSON
        const data = await response.json();

        // Hago la relacion con la propiedad 'data' de Reactjs usando setData
        setData(data);
      } catch (error) {
        console.error("Error leyendo pedidos:", error);
      }
    };

    fetchData();
  }, []);

  return (
    <TableContainer component={Paper}>
      Listado de Pedidos
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell align="right">Nombre</TableCell>
            <TableCell align="right">Hamburguesa</TableCell>
            <TableCell align="right">Cantidad</TableCell>
            <TableCell align="right">Precio</TableCell>
            <TableCell align="right">Fecha</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((row) => (
            <TableRow key={row.idPedido} sx={{ "&:last-child td, &:last-child th": { border: 0 } }}>
              <TableCell align="right">{row.cliente.nombre} {row.cliente.apellido}</TableCell>
              <TableCell align="right">{row.hamburguesa.nombreHamburguesa}</TableCell>
              <TableCell align="right">{row.cantidad}</TableCell>
              <TableCell align="right">
                ${row.cantidad > 1 ? row.cantidad * row.hamburguesa.precio : row.hamburguesa.precio}
              </TableCell>
              <TableCell align="right">{row.fecha}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default PedidosPage;
