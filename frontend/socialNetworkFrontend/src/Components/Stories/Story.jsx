import React from 'react';
import styles from './Story.module.scss';
import image from '../../assets/avatar.jpg';

export default function Story() {
    return (
        <div className={styles.wrapper}>
            <div className={styles.circle}>
                <img className={styles.ava} src={image} alt="User Avatar" />
            </div>
            Ramadanovna
        </div>
    );
}
