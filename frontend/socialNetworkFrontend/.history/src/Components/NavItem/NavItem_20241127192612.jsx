import React from 'react';
import { IoPerson } from 'react-icons/io5';
import styles from './NavItem.module.scss';

const NavItem = () => {
  return (
    <div>
      <IoPerson />
      <span className={styles.nav_item}>Моя страница</span>
    </div>
  );
};

export default NavItem;
