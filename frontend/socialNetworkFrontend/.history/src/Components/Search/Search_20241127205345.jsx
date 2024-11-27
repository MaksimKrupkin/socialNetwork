import React from 'react';
import styles from './Search.Module.scss';
import { IoSearchSharp } from 'react-icons/io5';

function Search() {
  return (
    <div className={styles.wrapper}>
      <IoSearchSharp />
    </div>
  );
}

export default Search;
