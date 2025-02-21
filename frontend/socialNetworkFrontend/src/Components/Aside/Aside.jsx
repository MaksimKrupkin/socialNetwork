import React from 'react';
import Search from '../Search/Search';
import styles from './Aside.module.scss';
import Recomendations from "../Recomendations/Recomendations.jsx";

function Aside() {
  return (
    <div className={styles.wrapper}>
        <Search />
        <Recomendations />
    </div>
  );
}

export default Aside;
