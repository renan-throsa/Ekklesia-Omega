import { useTheme } from '@mui/material';
import Button from '@mui/material/Button';
import './styles/App.css';

function App() {
  const dotenvv = process.env.REACT_APP_NOT_SECRET_CODE;
  return (
    <div className="App">
      <p>Hello, World</p>
      <Button variant="contained"> Olá Mundo: {dotenvv}</Button>
    </div>
  );
}

export default App;
