import React from 'react';
import { IoPerson } from 'react-icons/io5';
import styles from './Navigation.module.scss';

const Navigation = () => {
  return (
    <div className={styles.wrapper}>
      <div className={styles.item}>
        <IoPerson fontSize={20} />
        <span className={styles.text}>Моя страница</span>
      </div>
      <div className={styles.item}>
        <IoPerson fontSize={20} />
        <span className={styles.text}>Новости</span>
      </div>
      <div className={styles.item}>
        <IoPerson fontSize={20} />
        <span className={styles.text}>Мессенджер</span>
      </div>
      <div className={styles.item}>
        <IoPerson fontSize={20} />
        <span className={styles.text}>Подписки</span>
      </div>
      <div className={styles.item}>
        <IoPerson fontSize={20} />
        <span className={styles.text}>Подписчики</span>
      </div>
      <div className={styles.item}>
        <IoPerson fontSize={20} />
        <span className={styles.text}>Настройки</span>
      </div>
    </div>
  );
};

export default Navigation;
