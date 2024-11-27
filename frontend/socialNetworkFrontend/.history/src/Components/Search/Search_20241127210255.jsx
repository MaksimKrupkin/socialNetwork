import React from 'react';
import styles from './Search.module.scss';
import { IoSearchSharp } from 'react-icons/io5';

function Search() {
  return (
    <div className={styles.wrapper}>
      <IoSearchSharp style={{ color: 'gray', fontSize: '20px' }} />
      <input type="text" placeholder="Поиск в Brimo" />
    </div>
  );
}

export default Search;
