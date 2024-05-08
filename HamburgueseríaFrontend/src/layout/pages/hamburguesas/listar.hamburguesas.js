import { useEffect, useState } from "react";
import * as React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";

const HamburguesasPage = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("https://localhost:44349/Hamburguesa");
        const data = await response.json();
        setData(data);
      } catch (error) {
        console.error("Error fetching hamburguesas:", error);
      }
    };

    fetchData();
  }, []);

  return (
    <TableContainer component={Paper}>
      Listado de Hamburguesas
      <Table aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell align="right">Nombre</TableCell>
            <TableCell align="right">Precio</TableCell>
            <TableCell align="right">Descripción</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((row) => (
            <TableRow key={row.idHamburguesa}>
              <TableCell align="right">{row.nombreHamburguesa}</TableCell>
              <TableCell align="right">${row.precio}</TableCell>
              <TableCell align="right">{row.descripcion}</TableCell>
              {/* Agrega aquí más celdas de acuerdo a tu estructura de datos */}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default HamburguesasPage;
