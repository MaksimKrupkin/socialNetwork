import React from 'react';
import { IoPerson } from 'react-icons/io5';
import styles from './NavItem.module.scss';

const NavItem = () => {
  return (
    <div className={styles.wrapper}>
      <IoPerson fontSize={22} />
      <span className={styles.text}>Моя страница</span>
    </div>
  );
};

export default NavItem;
