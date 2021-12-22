import { createTheme } from '@mui/material/styles';

const theme = createTheme({
  palette: { mode: 'light' },
  spacing: (factor: number) => `${0.25 * factor}rem`, // (Bootstrap strategy)
});

export default theme;
