// ClientesPage.js
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


const theme = createTheme({
  palette: {
    primary: {
      main: '#1976d2',
    },
    secondary: {
      main: '#dc004e',
    },
  },
});

const ClientesPage = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("https://localhost:44349/Cliente");
        const data = await response.json();
        setData(data);
      } catch (error) {
        console.error("Error leyendo clientes:", error);
      }
    };

    fetchData();
  }, []);

  return (
    <ThemeProvider theme={theme}>
      <TableContainer component={Paper}>
        Listado de Clientes
        <Table aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell align="right" >ID</TableCell>
              <TableCell align="right" >Nombre</TableCell>
              <TableCell align="right" >Apellido</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data.map((row) => (
              <TableRow key={row.idCliente}>
                <TableCell align="right">{row.idCliente}</TableCell>
                <TableCell align="right">{row.nombre}</TableCell>
                <TableCell align="right">{row.apellido}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </ThemeProvider>
  );
};

export default ClientesPage;
