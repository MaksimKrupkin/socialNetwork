import React from 'react';
import Search from '../Search/Search';
import styles from './Aside.module.scss';

function Aside() {
  return (
    <div className={styles.wrapper}>
      <Search />
    </div>
  );
}

export default Aside;
