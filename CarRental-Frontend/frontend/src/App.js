import './App.css';
import HomePage from './pages/HomePage';
import { BrowserRouter as Router,Routes,Route } from 'react-router-dom'
function App() {
  return (
    <Router>
      <Routes>
        <Route index path="/" element={<HomePage />} />
      </Routes>
    </Router>
  );
}

export default App;
