import './App.css';
import { Routes, Route } from 'react-router-dom';
import MainPage from './Pages/MainPage/MainPage';
import FollowersPage from './Pages/FollowersPage/FollowersPage';

function App() {
  return (
    <div>
      <Routes>
        <Route path="/" element={<FollowersPage />} />
      </Routes>
    </div>
  );
}

export default App;
