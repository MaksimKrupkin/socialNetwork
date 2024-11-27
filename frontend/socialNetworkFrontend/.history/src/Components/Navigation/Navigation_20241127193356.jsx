import React from 'react';
import { IoPerson } from 'react-icons/io5';
import styles from './Navigation.module.scss';

const Navigation = () => {
  return (
    <div className={styles.wrapper}>
      <IoPerson fontSize={20} />
      <span className={styles.text}>Моя страница</span>
    </div>
  );
};

export default Navigation;
