import './App.css';
import { Routes, Route } from 'react-router-dom';
import MainPage from './Pages/MainPage/MainPage';
import FollowersPage from './Pages/FollowersPage/FollowersPage';
import ProfilePage from './Pages/ProfilePage/ProfilePage';

function App() {
  return (
    <div>
      <Routes>
        <Route path="/" element={<ProfilePage />} />
      </Routes>
    </div>
  );
}

export default App;
