import { useEffect, useState } from "react";
import * as React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { tableStyles } from "./style.hamburguesas";


const theme = createTheme ({
  palette: {
    primary: {
      main: '#1976d2',
    },
    secondary: {
      main: '#dc004e',
    },
  },
});


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
    <ThemeProvider theme={theme}>
    <TableContainer component={Paper} style={tableStyles.container}>
      Listado de Hamburguesas
      <Table aria-label="simple table" style={tableStyles.table}>
        <TableHead>
          <TableRow>
            <TableCell align="right" style={tableStyles.headerCell}>Nombre</TableCell>
            <TableCell align="right" style={tableStyles.headerCell}>Precio</TableCell>
            <TableCell align="right" style={tableStyles.headerCell}>Descripción</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((row, index) => (
            <TableRow key={row.idHamburguesa} style={index % 2 === 0 ? {} : tableStyles.oddRow}>
              <TableCell align="right">{row.nombreHamburguesa}</TableCell>
              <TableCell align="right">${row.precio}</TableCell>
              <TableCell align="right">{row.descripcion}</TableCell>
              {/* Agrega aquí más celdas de acuerdo a tu estructura de datos */}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    </ThemeProvider>
  );
};

export default HamburguesasPage;
