import { Box, Container } from "@mui/material";
import NavBar from "./NavBar";
import CssBaseline from '@mui/material/CssBaseline';
import { Outlet, ScrollRestoration, useLocation } from "react-router";
import HomePage from "../../features/home/HomePage";

function App() {
  const location = useLocation();

  return (
    <Box sx={{ bgcolor: '#eeeeee', minHeight: '100vh' }}>
      <ScrollRestoration />
      <CssBaseline />
      {location.pathname === '/' ? <HomePage /> : (
        <>
          <NavBar />
          <Container maxWidth='xl' sx={{ pt: 12 }}>
            <Outlet />
          </Container>
        </>
      )}
    </Box>
  )
}

export default App
