import styles from './App.css';
import { Routes, Route } from 'react-router-dom';
import MainPage from './Pages/MainPage/MainPage';

function App() {
  return (
    <div className={styles.app_wrapper}>
      <Routes>
        <Route path="/" element={<MainPage />} />
      </Routes>
    </div>
  );
}

export default App;
